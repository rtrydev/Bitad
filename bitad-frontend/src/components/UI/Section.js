import Container from "./Container";
import styles from "./Section.module.css";

function Section(props) {
  return (
    <section id={props.id} className={props.className}>
      <Container className={styles.section__wrapper}>
        {props.children}
      </Container>
    </section>
  );
}

export default Section;
