import { Injectable } from '@angular/core';
import { HttpClient } from  '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { DemoModel } from '../models/demo-model';

@Injectable({
  providedIn: 'root'
})
export class DemoModelService {
  private url = environment.apiUrl + 'api/demo/';

  constructor(private http: HttpClient) { }

  getDemoModels(): Observable<Array<DemoModel>>{
    return this.http.get<Array<DemoModel>>(this.url);
  }
}
