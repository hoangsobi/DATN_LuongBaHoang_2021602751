import { HttpClientModule } from '@angular/common/http';
import { Component, Pipe, PipeTransform } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { FileUploadModule } from 'primeng/fileupload';
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


  files: File[] = []; // Lưu danh sách file
  file2: any;
  uploadedUrls: string[] = [];
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
  curColor: any;
  curSoLuong: any;
  curKichCo: any;

  showForm = false;
  curId: any;
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
    this._productService.getProductById(orderId).subscribe(data => {
      this.curProduct = data;
      this.curProduct.ngayTao = new Date(data.ngayTao);
      this.curProduct.ngayCapNhat = new Date(data.ngayCapNhat);
  })
  }

  deleteProduct(orderId: any){
    this.confirmationService.confirm({
      message: 'Xác nhận xóa danh mục này?',
      accept: async () => {
        this._productService.deleteSanPham(orderId).subscribe(data => {
          if(data.status == "success")
          {
            this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Xóa sản phẩm thành công'});
            this.getAll();
          }
          else
          {
            this._messageService.add({severity:'info', summary: 'Thông báo', detail: 'Xóa sản phẩm thất bại'});
          }
        })
      }
    }
    );
  }



  showAdd(){
    this.action = 0;
    this.resetBody();
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
  clearGanFile(): void {
    this.files = [];
  }

  clearGanFile2(): void {
    this.file2 = null;
  }

  // Xử lý upload
  myUploader(event: any): void {
    if (this.files.length === 0) {
      alert('Please select at least one file');
      return;
    }

    // this._imageService.uploadImages(this.files).subscribe(
    //   (response) => {
    //     this.uploadedUrls = response.urls; // Gán URL ảnh trả về
    //     this.body.imageUrls = this.uploadedUrls.join(',');
    //     this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Upload ảnh thành công', life: 3000});
    //   },
    //   (error) => {
    //     console.error('Error uploading images:', error);
    //     this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Có lỗi xảy ra, hãy thử lại sau', life: 3000});
    //   }
    // );
  }


  myUploader2(event: any): void {
    if (!this.file2) {
      alert('Please select at least one file');
      return;
    }

    // this._imageService.uploadImages(this.files).subscribe(
    //   (response) => {
    //     this.uploadedUrls = response.urls; // Gán URL ảnh trả về
    //     this.body.imageUrls = this.uploadedUrls.join(',');
    //     this._messageService.add({severity:'success', summary: 'Thông báo', detail: 'Upload ảnh thành công', life: 3000});
    //   },
    //   (error) => {
    //     console.error('Error uploading images:', error);
    //     this._messageService.add({severity:'error', summary: 'Thông báo', detail: 'Có lỗi xảy ra, hãy thử lại sau', life: 3000});
    //   }
    // );
  }


  addProduct(productId: any){
    this._productService.postSanPham(productId, this.curProduct).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Thêm sản phẩm thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  updateProduct(productId: any){
    this._productService.putSanPham(productId, this.curProduct).subscribe(data => {
        this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Sửa sản phẩm thành công'});
        this.showForm = false;
        this.getAll();
    })
  }

  updateSoLuong(){
    this._productService.updateSoLuong(this.curId, this.curColor, this.curKichCo, this.curSoLuong).subscribe(data => {
      this._messageService.add({severity:'success', summary: 'Thành công', detail: 'Cập nhật số lượng thành công'});
      this.getAll();
    })
  }

  getSoLuong(){
    this._productService.getSoLuong(this.curId, this.curColor, this.curKichCo).subscribe(data => {
      this.curSoLuong = data;
    })
  }

}
