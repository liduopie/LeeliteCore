import { BehaviorSubject } from 'rxjs';

export class SidebarConfig {
  public MainState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  public SecondaryState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  public RightState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public MobileMainState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public MobileMainFullscreenState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public MobileSecondaryState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public MobileSecondaryFullscreenState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public MobileRightState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public MobileRightFullscreenState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public MainToggle() {
    this.MainState.next(!this.MainState.value);
  }

  public SecondaryToggle() {
    this.SecondaryState.next(!this.SecondaryState.value);
  }

  public RightToggle() {
    this.RightState.next(!this.RightState.value);
  }

  public MobileMainToggle() {
    if (this.MobileMainState.value)
      this.MobileMainFullscreenState.next(false);
    this.MobileMainState.next(!this.MobileMainState.value);

  }
  public MobileMainFullscreenToggle() {
    this.MobileMainFullscreenState.next(!this.MobileMainFullscreenState.value);
  }

  public MobileSecondaryToggle() {
    if (this.MobileSecondaryState.value)
      this.MobileSecondaryFullscreenState.next(false);
    this.MobileSecondaryState.next(!this.MobileSecondaryState.value);
  }
  public MobileSecondaryFullscreenToggle() {
    this.MobileSecondaryFullscreenState.next(!this.MobileSecondaryFullscreenState.value);
  }

  public MobileRightToggle() {
    if (this.MobileRightState.value)
      this.MobileRightFullscreenState.next(false);
    this.MobileRightState.next(!this.MobileRightState.value);
  }
  public MobileRightFullscreenToggle() {
    this.MobileRightFullscreenState.next(!this.MobileRightFullscreenState.value);
  }
}
