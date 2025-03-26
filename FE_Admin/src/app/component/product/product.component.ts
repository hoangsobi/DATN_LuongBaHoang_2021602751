import { HttpClientModule } from '@angular/common/http';
import { Component, Pipe, PipeTransform, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { FileUpload, FileUploadModule } from 'primeng/fileupload';
import { PaginatorModule } from 'primeng/paginator';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { UserService } from '../../service/user.service';
import { CalendarModule } from 'primeng/calendar';
import { Dropdown, DropdownModule } from 'primeng/dropdown';
import { CategoryService } from '../../service/category.service';
import { OrderService } from '../../service/order.service';
import { PhuongThucVanChuyen, TrangThaiDonHang } from '../../Enums/Enums';
import { ProductService } from '../../service/product.service';
import { ImageService } from '../../service/image.service';
import { resolve } from 'path';
import { lastValueFrom } from 'rxjs';

@Pipe({ standalone: true, name: 'formatVnd' })
export class FormatVndPipe implements PipeTransform {
  transform(value: any): string {
    const soTien: number = parseFloat(value);

    // Kiểm tra nếu giá trị là NaN hoặc không phải số
    if (isNaN(soTien)) {
      // Trả về giá trị không thay đổi nếu không phải số
      return value;
    }

    // Định dạng số tiền trong đơn vị VND
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(soTien);
  }
}

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [
    ButtonModule,
    TableModule,
    FormsModule,
    HttpClientModule,
    DialogModule,
    ToastModule,
    ConfirmDialogModule,
    InputTextModule,
    InputNumberModule,
    CommonModule,
    CalendarModule,
    RouterModule,
    PaginatorModule,
    DropdownModule,
    FormatVndPipe,
    FileUploadModule,
],
providers:[
    ProductService,
    MessageService,
    ConfirmationService,
    CategoryService,
    ImageService
],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  @ViewChild('fileUpload2') fileUpload2!: FileUpload;
  @ViewChild('fileUpload') fileUpload!: FileUpload;

  files: File[] = []; // Lưu danh sách file
  file2: any;
  uploadedUrls: string[] = [];
  curListAnh = [];
  listColor = [
    {name: 'Đỏ', id: 1},
    {name: 'Cam', id: 2},
    {name: 'Vàng', id: 3},
    {name: 'Lục', id: 4},
    {name: 'Xanh Dương', id: 5},
    {name: 'Tím', id: 6},
    {name: 'Trắng', id: 8},
    {name: 'Đen', id: 7},
  ];
  curId: any;
  listSanPhamSoLuong = [
    { sanPhamId: '', mau: null, kichCo: 0, soLuong: 0 }  // Một mục đầu tiên trống để thêm thông tin
  ];

  showForm = false;
  action = 0; //0: them, 1: sua, 2: xoa
  listDanhMuc = [];
  listCategory: any;
  listOrderProduct: any;
  curProduct = {
    id: '',
    ngayTao: new Date(),
    ten: '',
    maSanPham: '',
    gia: 0,
    giaSauGiam: 0,
    loaiSanPhamId: '',
    moTa: '',
    ghiChu: '',
    chatLieu: '',
    duongDanAnh: '',
    ngayCapNhat: new Date(),
  };
  constructor(
    private _productService: ProductService,
    private _imageService: ImageService,
    private _messageService: MessageService,
    private confirmationService: ConfirmationService,
    private _categoryService: CategoryService,
  )
  {

  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getAll();
  }


  resetBody(){
    this.  curProduct = {
      id: '',
      ngayTao: new Date(),
      ten: '',
      maSanPham: '',
      gia: 0,
      giaSauGiam: 0,
      loaiSanPhamId: '',
      moTa: '',
      ghiChu: '',
      chatLieu: '',
      duongDanAnh: '',
      ngayCapNhat: new Date(),
    };
  }

  getAll(){
    this._productService.getAllDonHang().subscribe(data => {
      this.listDanhMuc = data;
    })
    this._categoryService.getAllDanhMuc().subscribe(data => {
      this.listCategory = data;
    })
  }

  showProduct(orderId: any){
    this.showForm = true;
    this.action = 1;
    this.curId = orderId;
    this.clearGanFile(null);
    this.clearGanFile2(null);
    this._productService.getProductById(orderId).subscribe(data => {
      this.curProduct = data;
      this.curListAnh = data.listAnhSanPham;
      this.curProduct.ngayTao = new Date(data.ngayTao);
      this.curProduct.ngayCapNhat = new Date(data.ngayCapNhat);
    })
    this._productService.getSoLuong(this.curId).subscribe(data => {
      this.listSanPhamSoLuong = data;
    });
  }

  deleteProduct(orderId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận xóa sản phẩm này?',
      accept: async () => {
        this._productService.deleteSanPham(orderId).subscribe(data => {
          if(data.status == "success")
          {
            this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Xóa sản phẩm thành công'});
            this.getAll();
          }
          else
          {
            this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Xóa sản phẩm thất bại: Sản phẩm đã được đặt hàng'});
          }
        })
      }
    }
    );
  }



  showAdd(){
    this.action = 0;
    this.clearGanFile(null);
    this.clearGanFile2(null);
    this.resetBody();
    this.curListAnh = [];
    this.showForm = true;
  }
  ganFile(event: any): void {
    this.files = event.currentFiles;
  }

  ganFile2(event: any): void {
    this.file2 = event.currentFiles[0];
  }
  // Xóa file khỏi danh sách khi người dùng bỏ chọn
  xoaGanFile(event: any): void {

  }

  xoaGanFile2(event: any): void {

  }

  // Xóa toàn bộ file khi người dùng clear danh sách
  clearGanFile($event: any): void {
    this.files = [];
    this.fileUpload.clear();
  }

  clearGanFile2($event: any): void {
    this.file2 = null;
    this.fileUpload2.clear();
  }

  // Xử lý upload
  myUploader(): Promise<void> {
    return new Promise((resolve, reject) => {
      if (this.files.length === 0) {
        return resolve();
      }

      this._imageService.uploadImages(this.files).subscribe(
        (response) => {
          this.uploadedUrls = response.urls;
          let listAnhSanPham: any[] = [];
          this.uploadedUrls.forEach((url) => {
            listAnhSanPham.push({
              duongDan: url,
              sanPhamId: this.curProduct.id
            });
          });
          console.log(listAnhSanPham);

          this._imageService.postAnhSanPham(listAnhSanPham).subscribe(
            () => resolve(),
            (error) => reject(error)
          );
        },
        (error) => reject(error)
      );
    });
  }


  myUploader2(): Promise<void> {
    return new Promise((resolve, reject) => {
      if (!this.file2) {
        return resolve(); // Không có file thì bỏ qua
      }

      this._imageService.uploadSingleImage(this.file2).subscribe(
        (response) => {
          this.curProduct.duongDanAnh = response.url;
          resolve();
        },
        (error) => reject(error)
      );
    });
  }


  async addProduct(){
    try {
      this.curProduct.id = crypto.randomUUID();

      await Promise.all([this.myUploader2()]);

      await lastValueFrom(this._productService.postSanPham(this.curProduct));

      await Promise.all([this.myUploader()]);

      // this._productService.postSanPham(this.curProduct).subscribe(data => {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm sản phẩm thành công'});
          this.showForm = false;
          this.clearGanFile(null);
          this.clearGanFile2(null);
          this.getAll();
      //})
    } catch (error) {
      console.error("Lỗi khi upload ảnh:", error);
    }
  }

  async updateProduct(productId: any){
    try {

      await Promise.all([this.myUploader(), this.myUploader2()]);
      this.curProduct.ngayCapNhat = new Date();
      this._productService.putSanPham(productId, this.curProduct).subscribe(data => {
          this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Sửa sản phẩm thành công'});
          this.showForm = false;
          this.clearGanFile(null);
          this.clearGanFile2(null);
          this.getAll();
      })
    } catch (error) {
      console.error("Lỗi khi upload ảnh:", error);
    }
  }

  updateSoLuong(){
    this._productService.updateSoLuong(this.curId, this.listSanPhamSoLuong).subscribe(data => {
      this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Cập nhật số lượng thành công'});
      this.getAll();
    })
  }

  addViewSoLuong(){
    this.listSanPhamSoLuong.push({
      sanPhamId: this.curId,
      soLuong: 0,
      kichCo: 0,
      mau: null
    });
  }

  xoaSub(i: any){
    this.listSanPhamSoLuong.splice(i, 1);
  }

}
