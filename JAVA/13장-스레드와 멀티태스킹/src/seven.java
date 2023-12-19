import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.*;

public class seven extends JFrame{
	private MyPanel panel=new MyPanel();

	public seven() {
		setTitle("스네이크 움직이기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.addKeyListener(new MyKeyListener());
			
		c.add(panel);
		
		c.setFocusable(true);
//		panel.requestFocus();
		setSize(800,600);
		setVisible(true);
	}
	class MyPanel extends JPanel implements Runnable{
		private JLabel testLabel;
		private String direction="up";
		private ImageIcon icon=new ImageIcon("images/26.jpg");
		private Image img=icon.getImage();
		private ImageIcon icon1=new ImageIcon("images/head.jpg");
		private Image img1=icon1.getImage();
		private Image smallImg1=img1.getScaledInstance(35, 35, Image.SCALE_SMOOTH);
		private ImageIcon smallIcon1=new ImageIcon(smallImg1);
		private ImageIcon icon2=new ImageIcon("images/body.png");
		private Image img2=icon2.getImage();
		private Image smallImg2=img2.getScaledInstance(35, 35, Image.SCALE_SMOOTH);
		private ImageIcon smallIcon2=new ImageIcon(smallImg2);
		private JLabel []label=new JLabel[10];
		private Vector <Point> v=new Vector<Point>();
		public MyPanel() {
			setLayout(null);
			snake();
			Thread th=new Thread(this);
			th.start();
		}
		public void snake() {
			label[0]=new JLabel(smallIcon1);
			label[0].setSize(35,35);
			label[0].setPreferredSize(new Dimension(100,100));
			label[0].setLocation(150,150);
			add(label[0]);
			for(int i=1;i<label.length;i++) {
				label[i]=new JLabel();
				label[i].setIcon(smallIcon2);
				label[i].setSize(35,35);
				label[i].setLocation(150,150+35*i);
				add(label[i]);
			}
		}
		public void setDirection(int keyCode) {
			switch(keyCode) {
			case 38: direction="up";break;
			case 40: direction="down";break;
			case 37: direction="left";break;
			case 39: direction="right";
			}
		}
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.drawImage(img, 0, 0, getWidth(), getHeight(), 0, 0, 1920, 1080, this);
		}
		public void run() {
			while(true) {
			try {
				v.removeAllElements();
				for(int i=0;i<label.length;i++) {
					v.add(label[i].getLocation());
				}
				int x=label[0].getX();
				int y=label[0].getY();
				switch(direction) {
				case"up":y-=35;label[0].setLocation(x,y);
				for(int i=1;i<label.length;i++) {
					int x1=v.get(i-1).x;
					int y1=v.get(i-1).y;
					label[i].setLocation(x1,y1);
				}
				break;
				case"down":y+=35;label[0].setLocation(x,y);
				for(int i=1;i<label.length;i++) {
					int x1=v.get(i-1).x;
					int y1=v.get(i-1).y;
					label[i].setLocation(x1,y1);
				}
				break;
				case"left":x-=35;label[0].setLocation(x,y);
				for(int i=1;i<label.length;i++) {
					int x1=v.get(i-1).x;
					int y1=v.get(i-1).y;
					label[i].setLocation(x1,y1);
				}
				break;
				case"right":x+=35;label[0].setLocation(x,y);
				for(int i=1;i<label.length;i++) {
					int x1=v.get(i-1).x;
					int y1=v.get(i-1).y;
					label[i].setLocation(x1,y1);
				}
				}
				Thread.sleep(200);
			}catch(InterruptedException e) {return;}
		}}
		}
	class MyKeyListener extends KeyAdapter{
		public void keyPressed(KeyEvent e) {
			panel.setDirection(e.getKeyCode());
		}
	}
	public static void main(String[]args) {
		new seven();
	}
}