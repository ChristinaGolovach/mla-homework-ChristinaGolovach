import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { DemoModelListComponent } from './demo-model/lists/demo-model-list/demo-model-list.component';
import { DemoModelService } from './demo-model/services/demo-model.service';
import { AppRoutingModule } from './app-routing/app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    DemoModelListComponent,
    ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    NgbModule.forRoot(),
    AppRoutingModule
  ],
  providers: [
    HttpClient,
    DemoModelService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
