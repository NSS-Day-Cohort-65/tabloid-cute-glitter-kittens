import { useState, useEffect } from "react";
import { getAllPosts, getAllPostsByCategory } from "../../managers/postManager";
import {
    Accordion,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
    FormGroup,
    Input,
    Label,
} from 'reactstrap';
import { getAllCategories } from "../../managers/categoryManager";

export default function PostsList() {
    const [posts, setPosts] = useState([]);
    const [open, setOpen] = useState('0');
    const [categories, setCategories] = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState(null);

    useEffect(() => {
        getAllPosts().then(setPosts);
    }, []);

    useEffect(() => {
        getAllCategories().then(setCategories);
    }, []);
    useEffect(() => {
         getAllPostsByCategory(selectedCategoryId).then(setPosts);
    }, [selectedCategoryId]);

    const toggle = (id) => {
        if (open === id) {
            setOpen('0');
        } else {
            setOpen(id);
        }
    };

    if (!posts.length) {
        return null;
    }
    return (
        <>
            <h1>
                Catty Posts
            </h1>

            <FormGroup>
            <Label>Filter by Category</Label>
            <Input
              type="select"
              value={selectedCategoryId}
              onChange={e => setSelectedCategoryId(e.target.value)}
            >
              <option value="0">Choose Category</option>
              {categories.map((c) => (
                <option key={c.id} value={c.id}>
                  {c.name}
                </option>
              ))}
            </Input>
            </FormGroup>
            
            <div>
                <Accordion open={open} toggle={toggle}>
                    {/* the below block of code displays post only if isAppoved === true */}
                    {/* {posts.map(p =>
                    p.isApproved ? (
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                "insert child component here"
                            </AccordionBody>
                        </AccordionItem>
                    ) : ""
                )} */}
                    {posts.map(p =>
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                <div className="container">

                                    <h5> {p.title}</h5>

                                    <p>{p.imageLocation}</p>
                                    {/* tested: will not show up if it's null */}

                                    <p>Writen By {p.userProfile.identityUser.userName}</p>

                                    <p>{new Date(p.createDateTime).toLocaleDateString()}</p>
                                    {/* should be published date, but nothing is published yet. */}
                                    {/* <p>{p.publishDateTime}</p> */}

                                    <p>{p.content}</p>
                                </div>
                            </AccordionBody>
                        </AccordionItem>
                    )}
                </Accordion>
            </div>
        </>
    )
}