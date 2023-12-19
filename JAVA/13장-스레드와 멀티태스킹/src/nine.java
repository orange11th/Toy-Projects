import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class nine extends JFrame{				//프레임
	private MyPanel panel=new MyPanel();
	public nine() {
		setTitle("스레드를 가진 겜블링");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocation(880,420);//Frame 화면중앙에 설정
		
		setContentPane(panel);
		
		setSize(600,400);
		setVisible(true);
	}
	class MyPanel extends JPanel implements Runnable{
		private JLabel []label=new JLabel[3];
		private int []random=new int[3];
		private boolean flag=false;
		private JLabel text;
		public MyPanel() {							//패널
			setLayout(null);
			setLabel();
			addMouseListener(new MyMouseListener());
			
			
			Thread th=new Thread(this);
			th.start();
		}
		synchronized public void start() {			//시작
			flag=true;
			this.notify();
		}
		synchronized public void waitForStart() {	//대기
			if(!flag)
				try {this.wait();}catch(InterruptedException e) {return;}
		}
		public void run() {							//쓰레드
			while(true) {
				waitForStart();
			try {for(int i=0;i<3;i++) {
				int tmp=(int)(Math.random()*3);		//경우의수가 너무 많아서 3개(0,1,2)로 줄임
				label[i].setText(Integer.toString(tmp));
				Thread.sleep(200);}
				if(label[0].getText().equals(label[1].getText())&&label[1].getText().equals(label[2].getText()))
					text.setText("축하합니다!!");
				else
					text.setText("아쉽군요");
				flag=false;}
			catch(InterruptedException e) {return;}
		}}
		public void setLabel() {					//라벨 생성
			for(int i=0;i<label.length;i++) {
				label[i]=new JLabel("0");
				label[i].setSize(120,100);
				label[i].setHorizontalAlignment(JLabel.CENTER);
				label[i].setFont(new Font("Serif",Font.BOLD,100));
				label[i].setLocation(60+180*i,50);
				label[i].setForeground(Color.yellow);
				label[i].setBackground(Color.magenta);
				label[i].setOpaque(true);
				add(label[i]);
			}
			text=new JLabel("마우스를 클릭할 때 마다 게임합니다.");
			text.setSize(400,100);
			text.setHorizontalAlignment(JLabel.CENTER);
			text.setForeground(Color.black);
			text.setFont(new Font("Serif",Font.BOLD,20));
			text.setLocation(100,200);
			add(text);
		}
	}
	class MyMouseListener extends MouseAdapter{		//리스너 구현
		public void mouseClicked(MouseEvent e) {
			panel.start();
		}
	}
	public static void main(String[]args) {
		new nine();
	}
}
