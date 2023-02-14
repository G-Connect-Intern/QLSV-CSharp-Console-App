using System;

namespace QLSVCMD
{
	class SinhVien
	{
		public string MaSV;
		public string TenSV;
		public DateOnly NgaySinh;
		public bool GioiTinh; // true => nam
		public string MaKhoa;
		public SinhVien(string mMaSV, string mTenSV, DateOnly mNgaySinh, bool mGioiTinh, string mMaKhoa)
		{
			MaSV = mMaSV;
			TenSV= mTenSV;
			NgaySinh = mNgaySinh;
			GioiTinh = mGioiTinh;
			MaKhoa = mMaKhoa;
		}
	}


	class Program
	{
		static int Menu()
		{
			Console.WriteLine("Nhap lua chon:");
			Console.WriteLine("1. Xem danh sach sinh vien");
			Console.WriteLine("2. Them sinh vien");
			Console.WriteLine("3. Xoa sinh vien");
			Console.WriteLine("4. Sua sinh vien");
			Console.WriteLine("5. Tim kiem sinh vien");
			Console.WriteLine("6. Xoa sinh vien");
			Console.WriteLine("0. Thoat");
			int option = Convert.ToInt32(Console.ReadLine());
			Console.Clear();
			return option;
		}
		static void Main(string[] args)
		{
			List<SinhVien> mSinhVienList = new List<SinhVien>();
			void showSinhVien()
			{
				Console.Clear();
				Console.WriteLine($"{"Ma SV".PadRight(10)}{"Ten SV".PadRight(30)}{"Ngay Sinh".PadRight(20)}{"Gioi tinh".PadRight(20)}Ma Khoa");
				foreach (SinhVien sv in mSinhVienList)
				{
					string sex = sv.GioiTinh ? "Nam" : "Nu";
					Console.WriteLine($"{sv.MaSV.PadRight(10)}{sv.TenSV.PadRight(30)}{Convert.ToString(sv.NgaySinh).PadRight(20)}{sex.PadRight(20)}{sv.MaKhoa}");
				}
			}
			void showOneSinhVien(SinhVien sv)
			{
				Console.Clear();
				string sex = sv.GioiTinh ? "Nam" : "Nu";
				Console.WriteLine($"{sv.MaSV.PadRight(10)}{sv.TenSV.PadRight(30)}{Convert.ToString(sv.NgaySinh).PadRight(20)}{sex.PadRight(20)}{sv.MaKhoa}");
			}
			SinhVien inputSinhVien()
			{
				Console.WriteLine("Nhap ma SV:");
				string maSV = Console.ReadLine();
				Console.WriteLine("Nhap ten SV:");
				string tenSV = Console.ReadLine();
				Console.WriteLine("Nhap ngay sinh:");
				DateOnly ngaySinh = DateOnly.Parse(Console.ReadLine());
				Console.WriteLine("Nhap gioi tinh:");
				bool gioiTinh = Console.ReadLine() == "Nam" ? true : false;
				Console.WriteLine("Nhap ma khoa:");
				string maKhoa = Console.ReadLine();
				return new SinhVien(maSV, tenSV, ngaySinh, gioiTinh, maKhoa);
			}
			void addSinhVien()
			{
				mSinhVienList.Add(inputSinhVien());
			}
			int findOneSinhVien(string msv) {
				for(int i = 0; i < mSinhVienList.Count; i++)
				{
					if (mSinhVienList[i].MaSV == msv)
					{
						return i;
					}
				}
				return -1;
			}
			void editSinhVien()
			{
				Console.WriteLine("Nhap ma sv can sua: ");
				string msv = Console.ReadLine();
				int index = findOneSinhVien(msv);
				if(index == -1)
				{
					Console.WriteLine("Khong ton tai sinh vien nay!");
				} else
				{
					mSinhVienList[index] = inputSinhVien();
				}
			}
			void findSinhVien(string info)
			{
				List<int> indexes = new List<int>();
				for (int i = 0; i < mSinhVienList.Count; i++)
				{
					if (mSinhVienList[i].MaSV == info || mSinhVienList[i].TenSV == info || Convert.ToString(mSinhVienList[i].NgaySinh) == info || mSinhVienList[i].MaKhoa == info)
					{
						indexes.Add(i);
					}
				}
				Console.WriteLine($"{"Ma SV".PadRight(10)}{"Ten SV".PadRight(30)}{"Ngay Sinh".PadRight(20)}{"Gioi tinh".PadRight(20)}Ma Khoa");
				foreach (int i in indexes)
				{
					showOneSinhVien(mSinhVienList[i]);
				}
				
			}
			// Fake list
			mSinhVienList.Add(new SinhVien("123", "Ta Minh Huy", new DateOnly(2003, 10, 12), true, "AT"));
			mSinhVienList.Add(new SinhVien("124", "Ta Minh Huy", new DateOnly(2003, 10, 12), true, "AT"));
			mSinhVienList.Add(new SinhVien("125", "Ta Minh Huy", new DateOnly(2003, 10, 12), true, "AT"));
			while (true)
			{
				int option = Menu();
				switch (option)
				{
					case 1:
						showSinhVien();
						break;
					case 2:
						addSinhVien();
						break;
					case 3:
						Console.Write("Nhap ma SV can xoa: ");
						if(findOneSinhVien(Console.ReadLine()) != -1)
						{ 
							mSinhVienList.RemoveAt(findOneSinhVien(Console.ReadLine()));
						} else
						{
							Console.WriteLine("Khong ton tai SV nay!");
						}
						break;
					case 4:
						editSinhVien();
						break;
					case 5:
						Console.Write("Nhap thong tin SV can tim: ");
						findSinhVien(Console.ReadLine());
						break;
				}
			}
		}
	}

}
