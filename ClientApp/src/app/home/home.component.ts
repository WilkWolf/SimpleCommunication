import { Component, OnInit } from '@angular/core';
import { ApiConnectionService } from '../api-connection-services/api-connection.service';
import { SumOfOrdersModel } from '../models/sumOfOrdersModel';
import { TopTenUserModel } from '../models/topTenUserModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  sumOfOrders?: SumOfOrdersModel[];
  topTenUsers?: TopTenUserModel[];
  sumOfOrdersHidden: boolean = true;
  topTenUsersHidden: boolean = true;
  sumOfOrdersData?: any;
  topTenUsersData?: any;
  constructor(private apiConnectionService: ApiConnectionService) { }

  ngOnInit(): void {
  }

  getTopTenUsers() {
    this.apiConnectionService.getTopTenUsers().subscribe(topTenUsers => { this.showTopTenUsersData(topTenUsers); });
  }

  getSumOfOrdersInSixMonths() {
    this.apiConnectionService.getSumOfOrdersInSixMonths().subscribe(sumOfOrders => { this.showSumOfOrdersData(sumOfOrders); });
  }

  showSumOfOrdersData(valueFromApi: SumOfOrdersModel) {
    this.sumOfOrdersData = valueFromApi;
    this.sumOfOrdersHidden = false;
    this.topTenUsersHidden = true;
    this.topTenUsersData = undefined;
  }

  showTopTenUsersData(valueFromApi: TopTenUserModel) {
    this.topTenUsersData = valueFromApi;
    this.topTenUsersHidden = false;
    this.sumOfOrdersHidden = true;
    this.sumOfOrdersData = undefined;
  }

}
