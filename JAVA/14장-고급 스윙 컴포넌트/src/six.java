import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class six extends JFrame{
	private JTextField jt1,jt2;
	private JButton calc,add;
	private JLabel ans;
	public six() {
		setTitle("다이얼로그 만들기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		CalcDialog dialog=new CalcDialog();
		
		c.setLayout(new FlowLayout());
		calc=new JButton("calculate");
		calc.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				dialog.setVisible(true);
			}
		});
		c.add(calc);
		
		ans=new JLabel("계산 결과 출력");
		ans.setFont(new Font("Serif",Font.BOLD,15));
		ans.setBackground(Color.green);
		ans.setOpaque(true);
		c.add(ans);
		
		setLocation(880,420);
		setSize(300,150);
		setVisible(true);
	}

class CalcDialog extends JDialog{
	public CalcDialog() {
		setTitle("Calculation Dialog");
		setLayout(new FlowLayout());
		jt1=new JTextField(15);
		jt2=new JTextField(15);
		JLabel jl=new JLabel("두 수를 더합니다.");
		jl.setFont(new Font("Serif",Font.BOLD,15));
		add(jl);
		add(jt1);
		add(jt2);
		JButton btn=new JButton("Add");
		btn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int i1=Integer.parseInt(jt1.getText());
				int i2=Integer.parseInt(jt2.getText());
				ans.setText(Integer.toString(i1+i2));
				setVisible(false);
			}
		});
		add(btn);
		
		setSize(250,180);
		setLocation(980,520);
	}
}
	public static void main(String[]args) {
		new six();
	}
}
