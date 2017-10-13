import { NgModule } from '@angular/core';
import { FileUploadComponent } from './fileupload.component';
import { FileUploadRoutingModule } from './fileupload-routing.module';
import { SharedModule } from '../shared/shared.module';
import { NameListService } from '../shared/name-list/name-list.service';
import { HttpModule } from '@angular/http';

@NgModule({
  imports: [FileUploadRoutingModule, SharedModule, HttpModule],
  declarations: [FileUploadComponent],
  exports: [FileUploadComponent],
  providers: [NameListService]
})
export class FileUploadModule { }
