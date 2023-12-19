import javax.swing.*;
import java.awt.*;
import java.util.*;

public class eight extends JFrame{
	private MyPanel panel=new MyPanel();
	public eight() {
		setTitle("눈 내리는 이미지");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		setContentPane(panel);
		
		setLocation(880,420);
		setSize(800,600);
		setVisible(true);
	}
	Vector <Point> v=new Vector<Point>();
	public void setPosition() {
		for(int i=0;i<50;i++) {
		int x=(int)(Math.random()*800);
		int y=(int)(Math.random()*600);
		v.add(new Point(x,y));
		}
	}
	class MyPanel extends JPanel implements Runnable{
		private ImageIcon icon=new ImageIcon("images/12.jpg");
		private Image img=icon.getImage();
		private Vector <Point> v=new Vector<Point>();
		public MyPanel() {
			Thread th=new Thread(this);
			th.start();
		}
		public void snow() {
			for(int i=0;i<80;i++) {
			int x=(int)(Math.random()*800);
			int y=(int)(Math.random()*600);
			v.add(new Point(x,y));
			}
		}
		public void snowFall() {
			for(int i=0;i<80;i++) {
				int tmpx=v.get(i).x;
				int tmpy=v.get(i).y;
				if(tmpy>600) {
					tmpx=(int)(Math.random()*800);
					tmpy=0;
				}
				else
					tmpy+=5;
				v.remove(i);
				v.add(i,new Point(tmpx,tmpy));
			}
		}
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.drawImage(img, 0, 0, getWidth(), getHeight(), 0, 0, 1920, 1080, this);
			g.setColor(Color.white);
			snow();
			for(int i=0;i<80;i++) {
				Point p=v.get(i);
				g.fillOval(p.x, p.y, 10, 10);
			}
			}
		public void run() {
			while(true) {
				try {
					Thread.sleep(150);
					snowFall();
					repaint();
				}catch(InterruptedException e) {return;}
			}
		}
		}
	public static void main(String[]args) {
		new eight();
}
}
