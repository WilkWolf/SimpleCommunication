import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TopTenUserModel } from '../models/topTenUserModel';
import { SumOfOrdersModel } from '../models/sumOfOrdersModel';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectionService {

  http: HttpClient;
  constructor(http: HttpClient) {
    this.http = http;
  }

  public getTopTenUsers(): Observable<TopTenUserModel> {
    return this.http.get<TopTenUserModel>('https://localhost:44352/GetTopTenClient');
  }

  public getSumOfOrdersInSixMonths(): Observable<SumOfOrdersModel> {
    return this.http.get<SumOfOrdersModel>('https://localhost:44352/GetSumOfOrders');
  }
}
