import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

declare const gtag: Function;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'StarTeam-Forum';

  constructor(private router: Router) {}

  setUpAnalytics() {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        gtag('config', 'UA-215551577-1', {
          page_path: event.urlAfterRedirects,
        });
      });
  }

  ngOnInit() {
    this.setUpAnalytics();
  }
}
