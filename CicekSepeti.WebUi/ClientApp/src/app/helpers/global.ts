import { Injectable, Inject, isDevMode } from '@angular/core';
@Injectable()
export class Globals {
  url: string;
  private domLayout;
  private gridApi;
  public onEdit: boolean = false;

  constructor(@Inject('BASE_URL') baseUrl2: string) {
    this.domLayout = 'autoHeight';
    if (isDevMode()) {
      this.url = "http://localhost:63177/api/"
    }
    else {
      this.url = baseUrl2 + 'api/';
    }
  }
  onRowSelected(params) {
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
}
