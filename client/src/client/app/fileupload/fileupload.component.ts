import { Component, OnInit, ViewChild } from '@angular/core';
import { NameListService } from '../shared/name-list/name-list.service';
import { RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Http } from '@angular/http';

@Component({
  moduleId: module.id,
  selector: 'sd-fileupload',
  templateUrl: 'fileupload.component.html',
  styleUrls: ['fileupload.component.css'],
})
export class FileUploadComponent implements OnInit {
  private apiEndPoint: string = 'http://localhost:5000/api/PdfManager/UploadFiles';
  // tslint:disable-next-line:member-ordering
  @ViewChild('fileInput') fileInput: any;
  // tslint:disable-next-line:no-empty
  ngOnInit() {

  }

  constructor(private http: Http) {

  }

  public upload() {
    const fileBrowser = this.fileInput.nativeElement;
    if (fileBrowser.files && fileBrowser.files[0]) {
      const formData = new FormData();
      formData.append('files', fileBrowser.files[0]);
      const xhr = new XMLHttpRequest();

      // let args: RequestOptionsArgs = {};
      // args.headers['Content-Type'] ='multipart/form-data';

      this.http.post(this.apiEndPoint, formData)
        .map(res => res.json())
        .subscribe((data) => console.log(data));
    }
  }

}
