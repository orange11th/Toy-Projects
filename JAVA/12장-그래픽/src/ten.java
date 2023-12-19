import javax.swing.*;
import java.awt.*;
public class ten extends JFrame{
	private MyPanel panel=new MyPanel();
	public ten(){
		setTitle("그래픽 이미지 연습");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		setContentPane(panel);
		
		setSize(730,490);//360 240 
		setVisible(true);
	}
	class MyPanel extends JPanel{
		private ImageIcon icon=new ImageIcon("images/022.jpg");
		private Image img=icon.getImage();
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.drawImage(img,0,0,getWidth()/2-5,getHeight()/2-5,	0,0,960,540, this);//앞의 좌표 4개 패널구역/뒤의 좌표 4개 사진구역
			g.drawImage(img, getWidth()/2+5,0,getWidth(),getHeight()/2-5, 	960, 0, 1920, 540, this);
			g.drawImage(img,0,getHeight()/2+5,getWidth()/2-5,getHeight(),0,540,960,1080,this);
			g.drawImage(img,getWidth()/2+5,getHeight()/2+5,getWidth(),getHeight(),960,540,1920,1080,this);
		}
	}
	public static void main(String[]args) {
		new ten();
	}
}
