import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  url = 'https://localhost:7295/api/cloudinary';
  urlAnhSanPham = 'https://localhost:7295/api/anhsanphams'
  constructor(
    private http: HttpClient,
  ) { }

  uploadSingleImage(file: File): Observable<any> {
    const formData = new FormData();

      formData.append('file', file); // Key 'file' phải khớp với API

    return this.http.post(`${this.url}/upload`, formData);
  }

  uploadImages(files: File[]): Observable<any> {
    const formData = new FormData();

    files.forEach((file) => {
      formData.append('files', file); // Key 'files' phải khớp với API
    });

    return this.http.post(`${this.url}/upload-multiple`, formData);
  }

  postAnhSanPham(listAnhSanPham: any): Observable<any> {
    return this.http.post(`${this.urlAnhSanPham}/AddMultiple`, listAnhSanPham);
  }
}
