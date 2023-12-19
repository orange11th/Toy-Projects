import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
public class ten extends JFrame{
	JLabel []label=new JLabel[11];
	String[]list= {"0","1","2","3","4","5","6","7","8","9"};
	int stack=0;
	public void setLabel() {
		for(int i=0;i<list.length;i++) {
			label[i].setLocation((int)(Math.random()*540),(int)(Math.random()*540));
			label[i].setVisible(true);
		}
	}
	class MyMouseListener extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			JLabel jl=(JLabel) e.getSource();
			if(jl.getText().equals(Integer.toString(stack))) {
			jl.setVisible(false);
			stack++;
			if(jl.getText().equals("9")) {
				setLabel();
				stack=0;
			}
			}
		}
	}
	public ten() {
		setTitle("Ten 레이블 출력");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(600,600);
		setVisible(true);
		
		Container c=getContentPane();
		c.setLayout(null);
		
		for(int i=0;i<list.length;i++) {
			label[i]=new JLabel(list[i]);
			label[i].setSize(20,20);
			label[i].setFont(new Font("Serif",Font.BOLD,20));
			label[i].setForeground(Color.MAGENTA);
			int x=(int)(Math.random()*550);
			int y=(int)(Math.random()*550);
			label[i].setLocation(x,y);
			label[i].addMouseListener(new MyMouseListener());
			c.add(label[i]);
		}
		
		setLabel();
	}
	public static void main(String[]args) {
		new ten();
	}
}
