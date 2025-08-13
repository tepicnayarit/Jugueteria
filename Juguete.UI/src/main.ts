import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

bootstrapApplication(App, {
      providers: [
        provideHttpClient(),
      ],
    });