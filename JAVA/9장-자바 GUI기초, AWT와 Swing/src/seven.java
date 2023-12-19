import javax.swing.*;
import java.awt.*;
@SuppressWarnings("serial")
class cal extends JFrame{
	public cal(String name) {
		String []str= {"0","1","2","3","4","5","6","7","8","9","CE","계산","+","-","x","/"};
		JButton []jb=new JButton[str.length];
		setTitle(name);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel jp1=new JPanel();
		JPanel jp2=new JPanel();
		JPanel jp3=new JPanel();
		
		Container c=getContentPane();
		c.setLayout(new BorderLayout());
		c.add(jp1,BorderLayout.NORTH);
		c.add(jp2,BorderLayout.CENTER);
		c.add(jp3,BorderLayout.SOUTH);
		
		jp1.setBackground(Color.lightGray);
		jp1.add(new JLabel("수식입력"));
		jp1.add(new JTextField(20));
		
		jp2.setBackground(Color.white);
		jp2.setLayout(new GridLayout(4,4,2,2));
		for(int i=0;i<str.length;i++){
			jb[i]=new JButton(str[i]);
			if(i>11)
				jb[i].setBackground(Color.cyan);
			jp2.add(jb[i]);}		
		
		jp3.setBackground(Color.yellow);
		jp3.add(new JLabel("계산 결과"));
		jp3.add(new JTextField(20));
		
		setSize(400,400);
		setVisible(true);
		
		}
}
public class seven {
	public static void main(String[]args) {
		new cal("계산기 프레임");
	}
}
