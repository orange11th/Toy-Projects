import java.util.Scanner;
public class eight {
	public static void main (String[]args) {
		Scanner sc=new Scanner(System.in);
		System.out.print("정수 몇 개?");
		int i=sc.nextInt();
		int []a=new int[i];
		for(int j=0;j<a.length;j++) {
			a[j]=(int)(Math.random()*100)+1;
			for(int k=0;k<j;k++){
					if(a[k]==a[j])
						j--;
		}
	}sc.close();
		int ten=a.length/10;
		int start=0;
		for(i=0;i<ten;i++) {
			for(int j=0;j<10;j++)
				System.out.print(a[start+j]+" ");
			System.out.println();
			start+=10;
		}
		for(i=start;i<a.length;i++)
			{System.out.print(a[i]+" ");}
		
	}
}
