import { Directive, ElementRef, HostBinding, HostListener, Input, OnInit, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appFontWeightBold]'
})
export class FontWeightBoldDirective implements OnInit {
  @HostBinding('style.backgroundColor') backgroundColor: string;
  @Input() hightlightColor: string = 'black';

  constructor(private elRef: ElementRef, private renderer: Renderer2) { 
  }

  ngOnInit() {
    this.renderer.setStyle(this.elRef.nativeElement, 'font-weight', 'bold');
  }

  @HostListener('mouseenter') mouseenter(eventData: Event) {
    this.backgroundColor = this.hightlightColor;
  }

  @HostListener('mouseleave') mouseleave(eventData: Event) {
    this.backgroundColor = 'blue';
  }
}
