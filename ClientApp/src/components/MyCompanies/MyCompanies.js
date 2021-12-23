import s from "./MyCompanies.module.css";
import icon from "../../images/icon.png";
function Header() {
  return (
    <header className={s.header}>
      <div className={s.logo}>
        <img className={s.icon} src={icon} alt={"logo"} />
      </div>
      <div className={s.titlePosition}>
        <h1 className={s.title}>My companies</h1>
        <p className={s.description}>
          According to the EE Business Register, the following companies are related to you.
        </p>
      </div>
    </header>
  );
}

export default Header;
