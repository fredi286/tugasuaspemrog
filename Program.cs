using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplikasiPegawai;

namespace AplikasiPegawai

{
    public abstract class Pegawai
    {
        public string Nama { get; set; }
        public string Nik { get; set; }
        public string jenis_pegawai { get; set; }

        public abstract int Gaji();
    }
    public class Leader : Pegawai
    {
        public int JumlahPenjualan { get; set; }
        public int Komisi { get; set; }

        public override int Gaji() => JumlahPenjualan * Komisi;

    }

    public class PegawaiHarian : Pegawai
    {
        public int UpahPerJam { get; set; }
        public int JumlahJamKerja { get; set; }

        public override int Gaji() => UpahPerJam * JumlahJamKerja;

    }


    public class PegawaiTetap : Pegawai
    {
        public int GajiBulanan { get; set; }

        public override int Gaji() => GajiBulanan;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pegawai> listPegawai = new List<Pegawai>();

            void tampilPegawai()
            {
                int noUrut = 1;

                foreach (Pegawai pegawai in listPegawai)
                {
                    Console.WriteLine("{0}. Nik : {1}, Nama : {2}, Gaji: {3:NO}, {4}", noUrut, pegawai.Nik, pegawai.Nama, pegawai.Gaji(), pegawai.jenis_pegawai);

                    noUrut++;
                }
            }
            void tambahPegawaiTetap(string jenisPegawai, string nik, string nama, int gajiBulanan)
            {
                listPegawai.Add(new PegawaiTetap { jenis_pegawai = jenisPegawai, Nik = nik, Nama = nama, GajiBulanan = gajiBulanan });
            }
            void tambahPegawaiHarian(string jenisPegawai, string nik, string nama, int jamkerja, int upah)
            {
                listPegawai.Add(new PegawaiHarian { jenis_pegawai = jenisPegawai, Nik = nik, Nama = nama, JumlahJamKerja = jamkerja, UpahPerJam = upah });
            }
            void tambahLeader(string jenisPegawai, string nik, string nama, int jumlahjual, int komisi)
            {
                listPegawai.Add(new Leader { jenis_pegawai = jenisPegawai, Nik = nik, Nama = nama, JumlahPenjualan = jumlahjual, Komisi = komisi });
            }

            void hapusPegawai()
            {
                int no = 1;
                int jumlah_peg = 0;

                foreach (Pegawai pegawai in listPegawai)
                {
                    Console.WriteLine("{0} NIk: {1} ", no, pegawai.Nik);

                    no++;
                    jumlah_peg += 1;
                }
                Console.WriteLine();
                Console.Write("Pilih data yang akan dihapus [1-");
                Console.Write(jumlah_peg);
                Console.Write("] : ");
                int index_nik = int.Parse(Console.ReadLine());
                index_nik = index_nik - 1;

                listPegawai.RemoveAt(index_nik);
                Console.WriteLine();
                Console.WriteLine("Data Berhasil dihapus");
                Console.WriteLine();
                Console.WriteLine("\nTekan Enter Untuk Kembali ke Menu");
            }

            bool keluar = false;
            while (keluar == false)
            {
                Console.WriteLine("Pilih Menu Aplikasi: ");
                Console.WriteLine();
                Console.WriteLine("1. Tambah Data Pegawai");
                Console.WriteLine("2. Hapus Data Pegawai");
                Console.WriteLine("3. Tampilan Data Pegawai");
                Console.WriteLine("4. Keluar");
                Console.WriteLine();
                Console.Write("Nomer Menu [1..4] = ");
                int menu = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine();
                if (menu < 1)
                {
                    Console.WriteLine("Maaf, Menu Yang Anda Pilih Tidak Tersedia");
                }
                else if (menu > 4)
                {
                    Console.WriteLine("Maaf, Menu Yang Anda Pilih Tidak Tersedia");
                }
                else if (menu == 1)
                {
                    Console.WriteLine("Tambah Data Karyawan");
                    Console.WriteLine();
                    Console.Write("Jenis Karyawan [1. Pegawai Tetap, 2. Pegawai Harian, 3. Leader] : ");
                    int jp = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (jp == 1)
                    {
                        Console.Write("Nik = ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama = ");
                        string nama = Console.ReadLine();
                        Console.Write("Gaji Bulanan = ");
                        int gb = int.Parse(Console.ReadLine());
                        string jenis = "Pegawai Tetap";

                        tambahPegawaiTetap(jenis, nik, nama, gb);
                    }
                    else if (jp == 2)
                    {
                        Console.Write("Nik = ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama = ");
                        string nama = Console.ReadLine();
                        Console.Write("Jumlah Jam Kerja = ");
                        int jamkerja = int.Parse(Console.ReadLine());
                        Console.Write("Upah Per Jam = ");
                        int upah = int.Parse(Console.ReadLine());
                        string jenis = "Pegawai Harian";

                        tambahPegawaiHarian(jenis, nik, nama, jamkerja, upah);
                    }
                    else if (jp == 3)
                    {
                        Console.Write("Nik = ");
                        string nik = Console.ReadLine();
                        Console.Write("Nama = ");
                        string nama = Console.ReadLine();
                        Console.Write("Jumlah Jual = ");
                        int jumlahjual = int.Parse(Console.ReadLine());
                        Console.Write("Komisi = ");
                        int komisi = int.Parse(Console.ReadLine());
                        string jenis = "Leader";

                        tambahLeader(jenis, nik, nama, jumlahjual, komisi);
                    }
                    else
                    {
                        Console.WriteLine("Menu salah");
                    }
                    Console.WriteLine();
                    Console.WriteLine("\nTekan Enter Untuk Kembali ke Menu");
                }
                else if (menu == 2)
                {
                    hapusPegawai();
                }
                else if (menu == 3)
                {
                    Console.WriteLine("Data Pegawai");
                    Console.WriteLine();
                    tampilPegawai();

                    Console.WriteLine("\nTekan Enter Untuk Kembali ke Menu");
                }
                else if (menu == 4)
                {
                    keluar = true;
                }

                Console.ReadKey();
            }
        }
    }
}
