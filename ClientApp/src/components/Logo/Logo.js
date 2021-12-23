import logo from "../../images/logo.png";
import s from "./Logo.module.css";
function Logo() {
  return (
    <div className={s.logo}>
      <img src={logo} alt={"logo"} />
    </div>
  );
}

export default Logo;
