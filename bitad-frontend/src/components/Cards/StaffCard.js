import Card from "./Card";
import styles from "./StaffCard.module.css";
import typograhpy from "../../assets/css/Typography.module.css";

import defaultPicture from "../../assets/images/staff.svg";

function StaffCard(props) {
  const profilePicture =
    props.picture.length === 0 ? defaultPicture : props.picture;

  return (
    <Card className={styles["card--staff"]}>
      <div className={styles.staff__profile}>
        <img
          src={profilePicture}
          alt={props.name}
          className={styles.profile__image}
        />
        <div>
          <p className={`${styles.profile__degree} ${typograhpy["small-p"]}`}>
            {props.degree}
          </p>
          <h4 className={styles.profile__name}>{props.name}</h4>
        </div>
      </div>
      <p
        className={`${styles.staff__description} ${typograhpy["small-p"]} ${typograhpy["text-align--center"]}`}
      >
        {props.description}
      </p>
    </Card>
  );
}

export default StaffCard;
