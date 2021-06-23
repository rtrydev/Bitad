import Card from "./Card";
import styles from "./SimpleCard.module.css";
import typography from "../../assets/css/Typography.module.css";
import { Link } from "react-router-dom";

function SimpleCard(props) {
  const { src, alt } = props.image;
  return (
    <Card className={styles["card--simple"]}>
      <div>
        <img src={src} alt={alt} className={styles.card__image} />
        <h3 className={styles.card_title}>{props.title}</h3>
        <p className={`${styles.card__description} ${typography["small-p"]}`}>
          {props.description}
        </p>
      </div>
      <div>
        <Link to={props.link}>Dowiedz się więcej</Link>
      </div>
    </Card>
  );
}

export default SimpleCard;
