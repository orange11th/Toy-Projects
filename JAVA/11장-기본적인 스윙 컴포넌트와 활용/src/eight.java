import java.awt.*;
import java.awt.event.*;
import java.util.Vector;
import java.io.*;
import javax.swing.*;
public class eight extends JFrame{
	JRadioButton left,right;
	Vector<ImageIcon> v=new Vector<ImageIcon>();
	String direction="null";
	File dir=new File("images");
	File files[]=dir.listFiles();
	JLabel imageLabel;
	int num=0;
	public eight() {
		setTitle("Image Gallery Practice Frame");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		
		ButtonGroup group=new ButtonGroup();//버튼 그룹 객체 생성
		
		JPanel radioPanel=new JPanel();
		left=new JRadioButton("left");
		right=new JRadioButton("right");

		group.add(left);
		group.add(right);
		radioPanel.add(left);
		radioPanel.add(right);
		left.addItemListener(new MyItemListener());
		right.addItemListener(new MyItemListener());
		
		for(int i=0;i<files.length;i++) {
			ImageIcon icon=new ImageIcon(files[i].toString());
			v.add(icon);
		}
		
		imageLabel=new JLabel(v.get(num));
		imageLabel.setSize(800,550);
		imageLabel.addMouseListener(new MyMouseListener());
		c.add(imageLabel,BorderLayout.CENTER);
		
		c.add(radioPanel,BorderLayout.NORTH);
		setSize(800,600);
		setVisible(true);
	}
	class MyItemListener implements ItemListener{
		public void itemStateChanged(ItemEvent e) {
			if(e.getStateChange()==ItemEvent.DESELECTED)
				return;
			if(right.isSelected())
				direction="right";
			else
				direction="left";
		}		
	}
	class MyMouseListener extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			if(direction.equals("right")&&num<files.length-1)
				{num++;imageLabel.setIcon(v.get(num));}
			else if(direction.equals("left")&&num!=0)
				{num--;imageLabel.setIcon(v.get(num));}
			else
				return;
		}
	}
	public static void main(String[]args) {
		new eight();
	}
}