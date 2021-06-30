import styles from "./Copyrights.module.css";
import typography from "../../assets/css/Typography.module.css";
import { Link } from "react-router-dom";

function Copyrights() {
  const currentYear = new Date().getFullYear();

  return (
    <div className={styles.copyrights}>
      <div className={styles.copyrights__links}>
        <Link to="/" className={typography["nav-link"]}>
          Polityka prywatności
        </Link>
        <Link to="/" className={typography["nav-link"]}>
          Regulamin
        </Link>
      </div>
      <div>{`© ${currentYear} Reset. Wszelkie prawa zastrzeżone.`}</div>
    </div>
  );
}

export default Copyrights;
