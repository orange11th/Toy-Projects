import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
public class nine extends JFrame{
	ImageIcon rock,scissors,paper;
	JButton rockBt,scissorsBt,paperBt;
	JPanel jp1,jp2;
	JLabel jl1,jl2,jl3;
	public nine() {
		setTitle("가위 바위 보 게임");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		
		rock=new ImageIcon("images/Rock.png");
		scissors=new ImageIcon("images/Scissors.png");
		paper=new ImageIcon("images/Paper.png");
		
		rockBt=new JButton(rock);
		scissorsBt=new JButton(scissors);
		paperBt=new JButton(paper);
		
		rockBt.setPreferredSize(new Dimension(250,350));		
		scissorsBt.setPreferredSize(new Dimension(250,350));		
		paperBt.setPreferredSize(new Dimension(250,350));		
		
		rockBt.addMouseListener(new MyMouseListener());
		scissorsBt.addMouseListener(new MyMouseListener());
		paperBt.addMouseListener(new MyMouseListener());
		
		jp1=new JPanel();
		jp1.setLayout(new FlowLayout());
		jp1.setBackground(Color.DARK_GRAY);
		jp2=new JPanel();
		jp2.setLayout(new FlowLayout());
		jp2.setBackground(Color.yellow);
		
		jp1.add(scissorsBt);
		jp1.add(rockBt);
		jp1.add(paperBt);
		
		jl1=new JLabel();
		jl2=new JLabel();
		jl3=new JLabel();
		jl3.setForeground(Color.red);
		
		jp2.add(jl1);
		jp2.add(jl2);
		jp2.add(jl3);
		c.add(jp1,BorderLayout.NORTH);
		c.add(jp2,BorderLayout.CENTER);
	
		setSize(800,800);
		setVisible(true);
	}
	public void program(int i) {//0=바위 1=가위 2=보
		int com=(int)(Math.random()*3);
		if(i==0) {jl1.setIcon(rock);jl1.setText("me");
		if(com==0) {jl2.setIcon(rock);jl2.setText("com ");jl3.setText("Same !!!");}
		else if(com==1) {jl2.setIcon(scissors);jl2.setText("com ");jl3.setText("Me !!!");}
		else if(com==2) {jl2.setIcon(paper);jl2.setText("com ");jl3.setText("Computer !!!");}
		}
		if(i==1) {jl1.setIcon(scissors);jl1.setText("me");
		if(com==0) {jl2.setIcon(rock);jl2.setText("com ");jl3.setText("Computer !!!");}
		else if(com==1) {jl2.setIcon(scissors);jl2.setText("com ");jl3.setText("Same !!!");}
		else if(com==2) {jl2.setIcon(paper);jl2.setText("com ");jl3.setText("Me !!!");}
		}
		if(i==2) {jl1.setIcon(paper);jl1.setText("me");
		if(com==0) {jl2.setIcon(rock);jl2.setText("com ");jl3.setText("Me !!!");}
		else if(com==1) {jl2.setIcon(scissors);jl2.setText("com ");jl3.setText("Computer !!!");}
		else if(com==2) {jl2.setIcon(paper);jl2.setText("com ");jl3.setText("Same !!!");}
		}
	}
	class MyMouseListener extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			if(e.getSource().equals(rockBt)) {program(0);}
			if(e.getSource().equals(scissorsBt)) {program(1);}
			if(e.getSource().equals(paperBt)) {program(2);}
		}
	}
	public static void main(String[]args) {
		new nine();
	}
}
