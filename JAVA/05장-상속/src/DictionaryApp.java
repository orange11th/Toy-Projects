abstract class PairMap {
   protected String KeyArray[];
   protected String valueArray[]; 
   abstract String get(String key); // key 값을 가진 value 리턴, 없으면 null 리턴
   abstract void put(String ket, String value);
   abstract String delete(String key); // key 값을 가진 아이템 (value와 함꼐) 삭제, 삭제된 value 값 리턴
   abstract int length();
}
class Dictionary extends PairMap{
	private int i;
	public Dictionary(int num) {KeyArray=new String[num];valueArray=new String[num];this.i=0;}
	String get(String key) {
		String value = null;
		try{for(int k=0;k<i;k++)
			if(KeyArray[k].equals(key))
				value=valueArray[k];}catch(Exception NullPointerException) {
					return null;
				}
		return value;
	}
	void put(String key, String value) {
		for(int k=0;k<i;k++) {
			if(KeyArray[k].equals(key))
				valueArray[k]=value;
		}
		KeyArray[i]=key;valueArray[i]=value;i++;
	}
	String delete(String key) {
		String value=null;
		for(int k=0;k<i;k++) {
			if(KeyArray[k].equals(key)) {
				value=valueArray[k];
				KeyArray[k]=null;
				valueArray[k]=null;}
			}i--;return value;}
	int length() {
		return i;
	}
}
public class DictionaryApp{
	public static void main(String[]args) {
		 Dictionary dic = new Dictionary(10);
		   dic.put("황기태", "자바");
		   dic.put("이재문", "파이선");
		   dic.put("이재문", "C++"); // 이재문의 값을 C++로 수정
		   System.out.println("이재문의 값은 "+dic.get("이재문"));
		   System.out.println("황기태의 값은 "+dic.get("황기태"));
		   dic.delete("황기태"); // 황기태 아이템 삭제
		   System.out.println("황기태의 값은 "+dic.get("황기태")); //삭제된 아이템 접근
		   System.out.println("배열의 요소 개수는 "+dic.length());
	}
}