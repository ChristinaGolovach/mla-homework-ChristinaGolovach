import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DemoModelListComponent} from '../demo-model/lists/demo-model-list/demo-model-list.component';

const routes: Routes=[
  { path: 'models', component: DemoModelListComponent },
]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
