import javax.swing.*;
import javax.swing.filechooser.*;
import java.awt.*;
import java.awt.event.*;
import javax.sound.sampled.*;
import java.io.*;

public class seven extends JFrame{
	private JLabel label;
	private Clip clip;
	public seven() {
		setTitle("오디오 파일을 찾아 연주/종료 제어");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLayout(new FlowLayout());
		
		createMenu();
		label=new JLabel();
		label.setText("오디오 파일을 선택하세요");
		label.setFont(new Font("Serif",Font.BOLD,17));
		add(label);
		
		setLocation(880,420);
		setSize(500,200);
		setVisible(true);
	}
	private void createMenu() {
		JMenuBar mb=new JMenuBar();
		JMenu audioMenu=new JMenu("오디오");
		
		JMenuItem playItem=new JMenuItem("연주");
		JMenuItem stopItem=new JMenuItem("종료");
		playItem.addActionListener(new OpenActionListener());
		stopItem.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				clip.stop();
				label.setText("오디오 파일을 선택하세요");
			}
		});
		
		audioMenu.add(playItem);
		audioMenu.add(stopItem);
		
		mb.add(audioMenu);
		setJMenuBar(mb);
	}
	private void loadAudio(String pathName) {
		try{
			clip=AudioSystem.getClip();
			File audioFile=new File(pathName);
			AudioInputStream audioStream=AudioSystem.getAudioInputStream(audioFile);
			clip.open(audioStream);}
		catch(IOException e) {e.printStackTrace();}
		catch(LineUnavailableException e) {e.printStackTrace();}
		catch(UnsupportedAudioFileException e) {e.printStackTrace();}
	}
	class OpenActionListener implements ActionListener{
		private JFileChooser chooser;
		public OpenActionListener() {
			chooser=new JFileChooser();
			chooser.setCurrentDirectory(new File("C:\\Users\\orang\\eclipse-workspace\\14장"));
		}
		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			FileNameExtensionFilter filter=new FileNameExtensionFilter("WAV files","wav");
			chooser.setFileFilter(filter);
			int ret=chooser.showOpenDialog(null);
			if(ret !=JFileChooser.APPROVE_OPTION) {JOptionPane.showMessageDialog(null, "파일을 선택하지 않았습니다","경고",JOptionPane.WARNING_MESSAGE);
			return;}
			String filePath=chooser.getSelectedFile().getPath();
			loadAudio(filePath);
			clip.start();
			label.setText(chooser.getSelectedFile().getName()+" 를 연주하고 있습니다.");
			}
		}
	public static void main(String[]args) {
		new seven();
	}
}
