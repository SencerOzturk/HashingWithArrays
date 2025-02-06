using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _6.hafta
{
    internal class Program
    {

        static int[] hash = new int[100]; // Hash tablosu tanımlandı

        // Hash fonksiyonu
        static int hashfunc(int data)
        {
            return data % hash.Length; // Data'nın hash dizisindeki indeksi
        }



        // Hash tablosuna eleman ekleme
        static void HashAdd(int data)
        {
            int indis = hashfunc(data); // Hash fonksiyonu ile indis hesapla
            if (hash[indis] == 0) // Eğer yer boşsa
            {
                hash[indis] = data; // Veriyi ekle
            }
            else if (hash[indis] != data) // Çakışma varsa ve o yerde hali hazırda eklenen eleman yoksa
            {
                for (int i = (indis + 1) % hash.Length; i != indis; i = (i + 1) % hash.Length) // Lineer probing ile sonraki boş yeri bul.Eşit degıl mı kontrolu tam bır tur atıldıgında durması ıcın.
                {
                    if (hash[i] == 0) // Boş yer bulundu
                    {
                        hash[i] = data;
                        return;
                    }
                    else if (hash[i] == data) // Aynı veri zaten daha onceden cakısıp o yere atandıysa atama.
                    {
                        return;
                    }
                }
                Console.WriteLine("Hash tablosu dolu. Veri eklenemedi.");
            }
        }

        // Hash tablosunda eleman arama
        static bool search(int data)
        {
            int indis = hashfunc(data); // Hash fonksiyonu ile indis hesapla
            if (hash[indis] == 0) return false; // Eğer yer boşsa veri yoktur
            if (hash[indis] == data) return true; // Eğer veri varsa
            for (int i = (indis + 1) % hash.Length; i != indis; i = (i + 1) % hash.Length) // Lineer probing ile ara
            {
                if (hash[i] == 0) return false; //butun cakısan elemanların doldugu yerın arasında da yoksa yoktur.
                if (hash[i] == data) return true; // Veri bulundu
            }
            return false; // Döngü biterse veri yoktur
        }

        // Hash tablosundan eleman silme
        static void delete(int data)
        {
            int indis = hashfunc(data); // Hash fonksiyonu ile indis hesapla
            if (search(data)) // Eğer veri varsa
            {
                if (hash[indis] == data) // Veriyi doğrudan bulduysan
                {
                    hash[indis] = 0; // Sıfırla (sil)
                }
                else // Çakışmadan dolayı başka yerdeyse
                {
                    for (int i = (indis + 1) % hash.Length; i != indis; i = (i + 1) % hash.Length) // Lineer probing ile ara
                    {
                        if (hash[i] == data) // Veriyi bulduğunda
                        {
                            hash[i] = 0; // Sıfırla (sil)
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Silinmek istenen veri bulunamadı.");
            }
        }


        //LINKED LIST KULLANARAK YAPTIGIMIZ DIGER 6.HAFTA (2) DE


    }
}


