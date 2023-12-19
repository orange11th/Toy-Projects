import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
@SuppressWarnings("serial")
public class seven extends JFrame{
	JLabel jl=new JLabel("Love Java");
	int font=15;
 	public seven(String name) {
		setTitle(name);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container c=getContentPane();
		
		c.setLayout(new FlowLayout());
		
		jl.setSize(250,50);
		jl.setFont(new Font("Serif",Font.BOLD,font));
		jl.addMouseWheelListener(new MyMouseListener());
		
		c.add(jl);
		
		setSize(300,200);
		setVisible(true);
	}
	class MyMouseListener implements MouseWheelListener{
		public void mouseWheelMoved(MouseWheelEvent e) {
			int n=e.getWheelRotation();
			if(n<0&&font>5)
				{font-=5;jl.setFont(new Font("Serif",Font.BOLD,font));}
			else if(n>0)
				{font+=5;jl.setFont(new Font("Serif",Font.BOLD,font));}
		}
	}
	public static void main(String[]args) {
		new seven("마우스 휠을 굴려 폰트 크기 조절");
	}
}
