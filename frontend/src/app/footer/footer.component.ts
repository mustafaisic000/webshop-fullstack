import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  showFooter: boolean = true;
  constructor() { }

  ngOnInit(): void {
    if (window.location.pathname === '/login') {
      this.showFooter = false;
    }
  }

}
