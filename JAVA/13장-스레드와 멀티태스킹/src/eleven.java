import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.io.*;

public class eleven extends JFrame{
	private MyPanel panel=new MyPanel();
	private JPanel jp;
	private JTextField jt;
	private JLabel jl1,jl2;
	private Vector <String> v=new Vector<String>();
	public eleven() {
		setTitle("떨어지는 단어 맞추기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		panel.getWord();
		
		setLocation(880,420);
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		
		jt=new JTextField(10);
		jt.addActionListener(new MyActionListener());
		jp=new JPanel();
		jp.setBackground(Color.LIGHT_GRAY);
		jp.add(jt);
		c.add(jp,BorderLayout.SOUTH);
		c.add(panel,BorderLayout.CENTER);
		jl2.setText(v.get((int)(Math.random()*25142)));

		setSize(300,400);
		setVisible(true);
	}
class MyPanel extends JPanel implements Runnable{
	public MyPanel() {
		setLayout(null);
		jl1=new JLabel();
		jl1.setFont(new Font("Serif",Font.BOLD,18));
		jl1.setSize(120,20);
		jl1.setLocation(10,10);
		add(jl1);
		jl2=new JLabel("test");
		
		jl2=new JLabel();
		jl2.setFont(new Font("Serif",Font.BOLD,35));
		jl2.setSize(400,50);
		jl2.setForeground(Color.magenta);
		jl2.setLocation((int)(Math.random()*400/2),0);
		add(jl2);
		
		Thread th=new Thread(this);
		th.start();
	}
	public void run() {
		while(true) {
			try {
				Point p=jl2.getLocation();
				jl2.setLocation(p.x,p.y+10);//너무 느려서 10픽셀로 바꿈
				Thread.sleep(200);
				if(p.y>panel.getHeight()-15)
					{jl1.setText("시간초과실패");jl2.setText(v.get((int)(Math.random()*25142)));
					jl2.setLocation((int)(Math.random()*panel.getWidth()/2),0);}
			}catch(InterruptedException e) {return;}
		}
	}
	public void getWord() {
		try {FileReader fin=new FileReader("words.txt");//단어 25143개
		BufferedReader bf=new BufferedReader(fin);
		String line="";
		while((line=bf.readLine())!=null) {
			v.add(line);
		}}catch(IOException e) {System.out.println("파일이 없습니다.");};
	}
}
class MyActionListener implements ActionListener{
	public void actionPerformed(ActionEvent e) {
		if(jt.getText().equals(jl2.getText()))
			{jl1.setText("성공");
			jl2.setText(v.get((int)(Math.random()*25142)));
			jl2.setLocation((int)(Math.random()*panel.getWidth()/2),0);
			}
		if(jt.getText().equals("그만"))
			System.exit(0);//종료
		jt.setText("");
	}
}
	public static void main(String[]args) {
		new eleven();
	}
}
