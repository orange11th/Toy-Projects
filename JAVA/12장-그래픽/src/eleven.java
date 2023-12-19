import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class eleven extends JFrame{
	JPanel jp=new JPanel();
	MyPanel panel=new MyPanel();
	String[]fruits= {"apple","cherry","strawberry","prune"};
	JLabel[]jl=new JLabel[4];
	JLabel[]jl2=new JLabel[4];
	JTextField []jt=new JTextField[4];
	int []key=new int[4];//입력값
	int []ans=new int[4];//백분율
	int []ang=new int[4];//각도
	Color []col= {Color.red,Color.blue,Color.magenta,Color.yellow};
	public eleven() {
		setTitle("파이 차트 그리기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		
		jp.setLayout(new FlowLayout());
		jp.setBackground(Color.LIGHT_GRAY);
		for(int i=0;i<fruits.length;i++) {
			jl[i]=new JLabel(fruits[i]);
			jt[i]=new JTextField(5);
			jt[i].addActionListener(new MyActionListener());
			jp.add(jl[i]);
			jp.add(jt[i]);
		}

		panel.setLayout(null);
		for(int i=0;i<fruits.length;i++) {
			jl2[i]=new JLabel();
			panel.add(jl2[i]);
			jl2[i].setSize(120,20);
			jl2[i].setFont(new Font("Serif",Font.BOLD,15));
			jl2[i].setLocation(50+i*130, 0);
		}
		c.add(jp,BorderLayout.NORTH);
		c.add(panel,BorderLayout.CENTER);
		
		setSize(600,500);
		setVisible(true);
	}
	class MyPanel extends JPanel{
		public MyPanel() {
			addMouseListener(new MouseAdapter() {
				public void mousePressed(MouseEvent e) {
					System.out.println("click");
				}
			});
		}	
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.setColor(Color.red);
			g.fillArc(getWidth()/2-150, 100, 300, 300, 0, ang[0]);
			g.setColor(Color.blue);
			g.fillArc(getWidth()/2-150, 100, 300, 300, ang[0], ang[1]);
			g.setColor(Color.magenta);
			g.fillArc(getWidth()/2-150, 100, 300, 300, ang[0]+ang[1], ang[2]);
			g.setColor(Color.yellow);
			g.fillArc(getWidth()/2-150, 100, 300, 300, ang[0]+ang[1]+ang[2], ang[3]);
		}
	}
	class MyActionListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			double sum=0;
			for(int i=0;i<key.length;i++) {
				key[i]=Integer.parseInt(jt[i].getText());
				sum+=key[i];
			}
			for(int i=0;i<key.length;i++) {
				ans[i]=(int) Math.round(key[i]/sum*100);
				ang[i]=(int)Math.round(ans[i]*3.6);
			}
			for(int i=0;i<fruits.length;i++) {
				jl2[i].setText(fruits[i]+" "+ans[i]+"%");
				jl2[i].setForeground(col[i]);
			}
			panel.repaint();
		}	
	}
	public static void main(String[]args) {
		new eleven();
	}
}
