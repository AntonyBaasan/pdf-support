import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FileUploadComponent } from './fileupload.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', component: FileUploadComponent }
    ])
  ],
  exports: [RouterModule]
})
export class FileUploadRoutingModule { }
