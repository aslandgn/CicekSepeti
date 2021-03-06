import { Injectable, Inject, isDevMode } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable()
export class Globals {
  url: string;
  private domLayout;
  private gridApi;
  private rowIndex;
  public onEdit: boolean = false;

  constructor(@Inject('BASE_URL') baseUrl2: string, private jwtHelper: JwtHelperService) {
    this.domLayout = 'autoHeight';
    if (isDevMode()) {
      this.url = "http://localhost:63177/api/"
    }
    else {
      this.url = baseUrl2 + 'api/';
    }
  }
  onRowSelected(params) {
    debugger;
    if (params.rowIndex == this.rowIndex && params.node.selected == true) {
      console.log(1);
      this.rowIndex = params.rowIndex;
      return;
    }
    this.onEdit = params.node.selected;
  }

  onGridReady(params) {
    this.gridApi = params.api;
    params.api.sizeColumnsToFit();
  }

  getSelectedRowData() {
    let selectedNodes = this.gridApi.getSelectedNodes();
    let selectedData = selectedNodes.map(node => node.data);
    return selectedData;
  }

  statusRender(params) {
    return params.value ? 'active' : 'inactive'
  }
  hasValidToken() {
    var token = localStorage.getItem("token");
    return !this.jwtHelper.isTokenExpired(token);

  }
}
