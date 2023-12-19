import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
@SuppressWarnings("serial")
public class six extends JFrame{
	JLabel jl=new JLabel("C");
	public six(String name) {
		setTitle(name);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
		jl.setSize(10,10);
		jl.setLocation(100,100);
		
		Container c=getContentPane();
		jl.addMouseListener(new MyMouseListener());
		c.setLayout(null);
		c.add(jl);
		
		setSize(800,800);
		setVisible(true);
	}
	class MyMouseListener extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			int x=(int)(Math.random()*750);
			int y=(int)(Math.random()*750);
			jl.setLocation(x,y);
		}
	}
	public static void main(String[]args) {
		new six("클릭 연습 용 응용 프로그램");
	}
}
