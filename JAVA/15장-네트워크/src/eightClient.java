import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.net.Socket;

public class eightClient extends JFrame{
	private static final int DEFAULT_BUFFER_SIZE = 10000;
	private JButton btn1,btn2;
	private JTextField jt=new JTextField(25);
	private Socket socket=null;	
	private String filePath;
	private String fileName;
	public eightClient() {
		setLayout(new FlowLayout());
		add(jt);
		btn1=new JButton("이미지 선택");
		btn1.addActionListener(new OpenActionListener());
		btn2=new JButton("파일 전송");
		add(btn1);
		add(btn2);
		btn2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				sendFile(filePath);
			}
		});
		try {
			socket=new Socket("localhost",9999);
		}catch(IOException e) {
			System.out.println(e.getMessage());}
		setTitle("파일 전송 클라이언트");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocation(1080,420);
		setSize(400,150);
		setVisible(true);	
	}
	public void sendFile(String filePath){
		File file=new File(filePath);
		try {
			BufferedWriter out=new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
			out.write(fileName+"\n");
			out.flush();}catch(IOException e) {System.out.println(e.getMessage());}
		try {
			FileInputStream fi=new FileInputStream(file);
			DataOutputStream dos=new DataOutputStream(socket.getOutputStream());	
			byte[]buffer=new byte[1024];
			while(true) {
				int n=fi.read(buffer);
				dos.write(buffer,0,n);
				dos.flush();
				if(n<buffer.length)
					break;
			}
//			out.close();
			fi.close();
			dos.close();
		} catch (IOException e) {
			System.out.println(e.getMessage());
		}
	}
	class OpenActionListener implements ActionListener{
		private JFileChooser chooser;
		public OpenActionListener() {
			chooser=new JFileChooser();
			chooser.setCurrentDirectory(new File("C:\\Users\\orang\\eclipse-workspace\\15장"));
		}
		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			FileNameExtensionFilter filter=new FileNameExtensionFilter("JPG & GIF & PNG Images","jpg","gif","png");
			chooser.setFileFilter(filter);
			int ret=chooser.showOpenDialog(null);
			if(ret !=JFileChooser.APPROVE_OPTION) {JOptionPane.showMessageDialog(null, "파일을 선택하지 않았습니다","경고",JOptionPane.WARNING_MESSAGE);
			return;}
			fileName=chooser.getSelectedFile().getName();
			jt.setText(fileName);
			filePath=chooser.getSelectedFile().getPath();
			}
		}
	public static void main(String[]args) {
		new eightClient();
	}
}
