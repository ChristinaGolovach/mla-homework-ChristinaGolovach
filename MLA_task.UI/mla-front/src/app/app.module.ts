import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DemoModelListComponent } from './demo-model/lists/demo-model-list/demo-model-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DemoModelListComponent,
    ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
