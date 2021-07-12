import Card from "./Card";
import styles from "./SimpleCard.module.css";
import typography from "../../assets/css/Typography.module.css";
import { HashLink } from "react-router-hash-link";

function SimpleCard(props) {
  const { src, alt } = props.image;
  return (
    <Card className={styles["card--simple"]}>
      <div>
        <img src={src} alt={alt} className={styles.card__image} />
        <h3 className={styles.card_title}>{props.title}</h3>
        <p className={typography["small-p"]}>{props.description}</p>
      </div>
      <div>
        <HashLink to={props.link} className={typography["small-p"]}>
          Dowiedz się więcej
        </HashLink>
      </div>
    </Card>
  );
}

export default SimpleCard;
