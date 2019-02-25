import { Component, OnInit } from '@angular/core';
import { DemoModelService } from '../../services/demo-model.service';
import { DemoModel } from '../../models/demo-model';

@Component({
  selector: 'app-demo-model-list',
  templateUrl: './demo-model-list.component.html',
  styleUrls: ['./demo-model-list.component.css']
})
export class DemoModelListComponent implements OnInit {

  demoModels: DemoModel[];

  constructor(private demoModelService: DemoModelService) { }

  ngOnInit() {
    this.getDemoModel()
  }

  getDemoModel(){
    this.demoModelService.getDemoModels().subscribe(models => this.demoModels = models);
  }

}
