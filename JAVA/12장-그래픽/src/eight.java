import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.Vector;
	
public class eight extends JFrame{
	MyPanel Panel=new MyPanel();
	public eight() {
		setTitle("마우스로 원 그리기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		setContentPane(Panel);
		
		setSize(700,500);
		setVisible(true);
	}
	class MyPanel extends JPanel{
		private Vector<Point> start=new Vector<Point>();
		private Vector<Point> end=new Vector<Point>();
		public MyPanel() {
			addMouseListener(new MouseAdapter() {
				public void mousePressed(MouseEvent e) {
					start.add(e.getPoint());
				}
				public void mouseReleased(MouseEvent e) {
					end.add(e.getPoint());
					repaint();
				}
			}
		);}
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.setColor(Color.red);
			for(int i=0;i<start.size();i++) {
				Point s=start.get(i);
				Point e=end.get(i);
				double radius=Math.sqrt(Math.pow(Math.abs(s.getX()-e.getX()),2)+Math.pow(Math.abs(s.getY()-e.getY()),2));
				g.drawOval((int)Math.abs(s.getX()-radius), (int)(Math.abs(s.getY()-radius)), (int)radius*2, (int)radius*2);
		}
	}}
	public static void main(String[]args) {
		new eight();
	}
}