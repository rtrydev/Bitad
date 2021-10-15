import styles from "./Copyrights.module.css";
import typography from "../../assets/css/Typography.module.css";
import { Link } from "react-router-dom";

function Copyrights() {
  const currentYear = new Date().getFullYear();

  return (
    <div className={styles.copyrights}>
      <div className={styles.copyrights__links}>
        <Link
          to="/Regulamin.pdf"
          className={typography["nav-link"]}
          target="_blank"
        >
          Regulamin
        </Link>
      </div>
      <div>{`© ${currentYear} Reset. Wszelkie prawa zastrzeżone.`}</div>
    </div>
  );
}

export default Copyrights;
