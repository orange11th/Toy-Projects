import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ten extends JFrame{
	private MyPanel panel=new MyPanel();
	public ten() {
		setTitle("Make Drawing to start");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		setContentPane(panel);
		setLocation(880,420);
		
		setSize(500,500);
		setVisible(true);
	}
	class MyPanel extends JPanel implements Runnable{
		private boolean flag=false;
		private Graphics g;
		private int []size=new int[4];
		MyPanel(){
			addMouseListener(new MouseAdapter() {
				public void mouseEntered(MouseEvent e) {
					panel.On();
				}
				public void mouseExited(MouseEvent e) {
					flag=false;
				}
			});
			
			Thread th=new Thread(this);
			th.start();
		}
		public void draw(Graphics g,int x,int y,int width,int height) {
			g.fillOval(x,y,width,height);
		}
		synchronized public void On() {
			flag=true;
			this.notify();
		}
		synchronized public void Wait() {
			if(!flag)
				try {this.wait();}catch(InterruptedException e) {return;}
		}
		public void run() {
			while(true) {
				Wait();
				try {
					for(int i=0;i<size.length;i++) {
						size[i]=(int)(Math.random()*400+1);
					}
					repaint();
					Thread.sleep(300);
				}catch(InterruptedException e) {return;}
			}
		}
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.setColor(Color.magenta);
			draw(g,size[0],size[1],size[2],size[3]);
		}
	}
	public static void main(String[]args) {
		new ten();
	}
}
