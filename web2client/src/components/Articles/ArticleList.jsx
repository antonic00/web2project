import React from "react";
import Card from "react-bootstrap/Card";
import ListGroup from "react-bootstrap/ListGroup";
import ArticleItem from "./ArticleItem";

const ArticleList = ({ articles, canDelete, handleDelete }) => {
  return (
    <Card>
      <ListGroup variant="flush">
        {articles.map((article) => (
          <ListGroup.Item key={article.id}>
            <ArticleItem
              articleData={article}
              canDelete={canDelete}
              handleDelete={handleDelete}
            />
          </ListGroup.Item>
        ))}
      </ListGroup>
    </Card>
  );
};

export default ArticleList;