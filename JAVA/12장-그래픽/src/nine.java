import javax.swing.*;
import java.awt.*;

public class nine extends JFrame{
	public nine() {
		setTitle("Blue Label 만들기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new FlowLayout());
		
		BlueLabel bl=new BlueLabel("hello");
		bl.setBackground(Color.red);//배경색 변경
		bl.setForeground(Color.white);
		bl.setOpaque(true);
		
		BlueLabel bbl=new BlueLabel("Big Hello");
		bbl.setFont(new Font("Serif",Font.ROMAN_BASELINE,50));
		bbl.setForeground(Color.magenta);
		bbl.setBackground(Color.red);//배경색 변경
		bbl.setOpaque(true);
		
		c.add(bl);
		c.add(bbl);
		
		setSize(400,300);
		setVisible(true);
	}
	class BlueLabel extends JLabel{
		public BlueLabel(String s) {
			super(s);
		}
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			setBackground(Color.blue);
	}
	}
	public static void main(String[]args) {
		new nine();
	}
}
