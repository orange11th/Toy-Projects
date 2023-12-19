import java.io.*;
import java.net.*;
import java.util.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class sixServer extends JFrame{
	private JTextArea ja=new JTextArea(8,20);
	private HashMap<String,String> h=new HashMap<String,String>();
	private Socket socket=null;
	private ServerSocket listener=null;
	private JTextField jt1=new JTextField(8);
	private JTextField jt2=new JTextField(8);
	private JButton btn;
	public sixServer() {
		setTitle("Dic Server");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container c=getContentPane();
		c.setLayout(new FlowLayout());
		
		JPanel jp1=new JPanel();
		jp1.setLayout(new FlowLayout());
		jp1.add(new JLabel("영어"));
		jp1.add(jt1);
		jp1.add(new JLabel("한글"));
		jp1.add(jt2);
		btn=new JButton("저장");
		c.add(jp1);
		btn.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				ja.append("삽입 ("+jt1.getText()+","+jt2.getText()+")\n");
				h.put(jt1.getText(), jt2.getText());
			}
		});
		c.add(btn);
		
		ja.setBorder(BorderFactory.createLineBorder(Color.black,1));
		c.add(ja);
		
		setSize(300,300);
		setLocation(880,420);
		setVisible(true);
		try {
			listener=new ServerSocket(9999);
			while(true) {
			socket=listener.accept();
			program pro =new program(socket);
			pro.start();
			}
		}catch(IOException e) {
			System.out.println(e.getMessage());
		}finally {
			try {
				socket.close();
				listener.close();
			}catch(IOException e) {
				System.out.println("오류 발생");
			}
		}
	}
	class program extends Thread{
		Socket socket;
		public program(Socket socket) {
			this.socket=socket;
		}
		public void run() {
			try {
			BufferedReader in=new BufferedReader(new InputStreamReader(socket.getInputStream()));
			BufferedWriter out=new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
			while(true) {
				String inputMessage=in.readLine();
				ja.append("검색 ("+inputMessage+")\n");
				if(h.containsKey(inputMessage)) {
					out.write(h.get(inputMessage)+"\n");
					out.flush();
				}
				else {
					out.write("없음\n");
					out.flush();
				}			
			}
		}catch(IOException e) {System.out.println(e.getMessage());}
	}
	}
	public static void main(String[]args) {
		new sixServer();
	}
}