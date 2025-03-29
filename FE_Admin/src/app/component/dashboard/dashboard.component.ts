
import { DashboardService } from '../../service/dashboard.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { Component, Pipe, PipeTransform } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { ChartModule } from 'primeng/chart';
import { TableModule } from 'primeng/table';

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
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    HttpClientModule,
    RouterModule,
    CommonModule,
    FormsModule,
    ButtonModule,
    CalendarModule,
    ChartModule,
    TableModule,
    FormatVndPipe
  ],
  providers:[
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  dataHeader: any;

  dataDoanhThuChiPhi = {
    labels: ['Doanh thu', 'Chi phí'],
    datasets: [
        {
            data: [] as number[],
            backgroundColor: [
                "#42A5F5",
                "#66BB6A",
            ],
            hoverBackgroundColor: [
                "#64B5F6",
                "#81C784",
            ]
        }
    ]
  };
  dataDoanhThuTheoThangTrongNam = {
    labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6', 'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
    datasets: [
      {
          label: 'Doanh thu',
          data: [],
          fill: false,
          borderColor: '#42A5F5',
          tension: .4
      },
    ]
  };
  dataKhachThanThiet: any;
  dataDonHangGanNhat: any;


  constructor(
    private http: HttpClient,
    private _dashboardService: DashboardService,
  ) {


   } // Inject HttpClient into the constructor
  ngOnInit() {
    this.getAll();
  }

  getAll(){
    this._dashboardService.getHeaderThongKe().subscribe(res => {
      this.dataHeader = res;
    })
    this._dashboardService.getThongKeDoanhThuChiPhi().subscribe(data => {
      const updatedData = [data.doanhThu ?? 0, data.chiPhi ?? 0] ;
      this.dataDoanhThuChiPhi = {
        ...this.dataDoanhThuChiPhi,
        datasets: [{
          ...this.dataDoanhThuChiPhi.datasets[0],
          data: updatedData
        }]
      };
    })


    this._dashboardService.getDoanhThuTheoThangTrongNam().subscribe(data => {
      const updatedData = data.map((x: any) => x.totalOrders || 0);
      this.dataDoanhThuTheoThangTrongNam = {
        ...this.dataDoanhThuTheoThangTrongNam,
        datasets: [{
          ...this.dataDoanhThuTheoThangTrongNam.datasets[0],
          data: updatedData
        }]
      };
      console.log(this.dataDoanhThuTheoThangTrongNam);
    })


    this._dashboardService.getKhachThanThiet().subscribe(res => {
      this.dataKhachThanThiet = res;
    })


    this._dashboardService.getDonHangGanNhat().subscribe(res => {
      this.dataDonHangGanNhat = res;
    })
  }

}
