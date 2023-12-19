import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
 
// A class to store a graph edge
class Edge
{
    int source, dest, weight;
 
    public Edge(int source, int dest, int weight)
    {
        this.source = source;
        this.dest = dest;
        this.weight = weight;
    }
}
 
public class Bellman_Ford
{
	protected ArrayList<String> ansList;
    // Recursive function to print the path of a given vertex from source vertex
	protected ArrayList getList() {
		return ansList;
	}
    static void getPath(int parent[], int vertex, List<Integer> path)
    {
        if (vertex < 0) {
            return;
        }
 
        getPath(parent, parent[vertex], path);
        path.add(vertex);
    }
 
    // Function to run the Bellman–Ford algorithm from a given source
    public void bellmanFord(List<Edge> edges, int source, int n)
    {
        // distance[] and parent[] stores the shortest path
        // (least cost/path) information
        int distance[] = new int[n];
        int parent[] = new int[n];
    
 
        // initialize `distance[]` and `parent[]`. Initially, all vertices
        // except source vertex weight INFINITY and no parent
        Arrays.fill(distance, Integer.MAX_VALUE);
        distance[source] = 0;
 
        Arrays.fill(parent, -1);
 
        // relaxation step (run V-1 times)
        for (int i = 0; i < n - 1; i++)
        {
            for (Edge edge: edges)
            {
                // edge from `u` to `v` having weight `w`
                int u = edge.source;
                int v = edge.dest;
                int w = edge.weight;
 
                // if the distance to destination `v` can be
                // shortened by taking edge (u, v)
                if (distance[u] != Integer.MAX_VALUE && distance[u] + w < distance[v])
                {
                    // update distance to the new lower value
                    distance[v] = distance[u] + w;
 
                    // set v's parent as `u`
                    parent[v] = u;
                }
            }
        }
        ansList=new ArrayList<String>();
        // run relaxation step once more for n'th time to
        // check for negative-weight cycles
        for (Edge edge: edges)
        {
            // edge from `u` to `v` having weight `w`
            int u = edge.source;
            int v = edge.dest;
            int w = edge.weight;
 
            // if the distance to destination `u` can be
            // shortened by taking edge (u, v)
            if (distance[u] != Integer.MAX_VALUE && distance[u] + w < distance[v])
            {
                //System.out.println("Negative-weight cycle is found!!");
                ansList.add("Negative-weight cycle is found!!");
                return;
            }
        }
 
        for (int i = 0; i < n; i++)
        {
        	String ans="";
            if (i != source && distance[i] < Integer.MAX_VALUE) {
                List<Integer> path = new ArrayList<>();
                getPath(parent, i, path);
                /*
                System.out.println("시작 노드 " + source + "에서 노드 " +
                        i + "까지의 거리 : " + distance[i] + " || 경로: " + path);
                        */
                ans+="시작 노드 " + (char)(source+97) + "에서 노드 " +
                        (char)(i+97) + "까지의 거리 : " + distance[i] + " || 경로: ";
                for(int j=0;j<path.size();j++)
                	ans+=(char)(path.get(j)+97)+" ";
                ansList.add(ans);
            }
        }
    }
 
    public static void main(String[] args)
    {
    	Bellman_Ford b=new Bellman_Ford();
        // List of graph edges as per the above diagram
    	/*
        List<Edge> edges = Arrays.asList(
                // (x, y, w) —> edge from `x` to `y` having weight `w`
                new Edge(0, 1, -1), new Edge(0, 2, 4), new Edge(1, 2, 3),
                new Edge(1, 3, 2), new Edge(1, 4, 2), new Edge(3, 2, 5),
                new Edge(3, 1, 1), new Edge(4, 3, -3 )
           
        );*/
    	List<Edge> edges=new ArrayList<Edge>();
    	edges.add(new Edge(0,1,-1));
    	edges.add(new Edge(0,2,4));
    	edges.add(new Edge(1,2,3));
    	edges.add(new Edge(1,3,2));
    	edges.add(new Edge(1,4,2));
    	edges.add(new Edge(3,2,5));
    	edges.add(new Edge(3,1,1));
    	edges.add(new Edge(4,3,-3));
   
        // set the maximum number of nodes in the graph
        int n = 5;
        
        // run the Bellman–Ford algorithm from every node
        for (int source = 0; source < n; source++) {
            b.bellmanFord(edges, source, n);
        }
        //b.bellmanFord(edges, 0, n);
    }
}
