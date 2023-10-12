import { useState, useEffect } from "react";
import { getAllPosts, getAllPostsByCategory, getAllPostsByTag } from "../../managers/postManager";
import {
    Accordion,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
    Button,
    FormGroup,
    Input,
    Label,
} from 'reactstrap';
import { getAllCategories } from "../../managers/categoryManager";
import { getTags } from "../../managers/tagManager";
import { useNavigate, Link } from 'react-router-dom';



export default function PostsList() {
    const [posts, setPosts] = useState([]);
    const [open, setOpen] = useState('0');

    const [categories, setCategories] = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] = useState(0);


    const [tags, setTags] = useState([]);
    const [selectedTagId, setSelectedTagId] = useState(0);

    const [error, setError] = useState(null);


    useEffect(() => {
        getAllPosts().then(setPosts).catch((err) => setError(err));
    }, []);

    useEffect(() => {
        getAllCategories().then(setCategories);
    }, []);

    useEffect(() => {

        if(selectedCategoryId != 0)
        {
            setError(null); // reset error so message is gone on selection of another category
            getAllPostsByCategory(selectedCategoryId).then(setPosts).catch((err) => setError(err));
        } else {
            setError(null);
            getAllPosts()
            .then(setPosts)
            .catch((err) => setError(err));
        }

        getAllPostsByCategory(selectedCategoryId).then(setPosts);

    }, [selectedCategoryId]);

    useEffect(() => {
        getTags().then(setTags);
    }, []);

    useEffect(() => {
        if (selectedTagId !== 0) {
            setError(null);
            getAllPostsByTag(selectedTagId)
                .then(setPosts)
                .catch((err) => setError(err));
        } else {
            setError(null);
            getAllPosts()
                .then(setPosts)
                .catch((err) => setError(err));
        }
   }, [selectedTagId]);

    const toggle = (id) => {
        if (open === id) {
            setOpen('0');
        } else {
            setOpen(id);
        }
    };

    const navigate = useNavigate();

    const handleNavigate = (e) => {
        e.preventDefault()
        navigate('create')
    }

    

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
              <option value="0">...all posts</option>
              {categories.map((c) => (
                <option key={c.id} value={c.id}>
                  {c.name}
                </option>
              ))}
            </Input>

            <Label>Filter by Tag</Label>
            <Input
              type="select"
              value={selectedTagId}
              onChange={e => setSelectedTagId(e.target.value)}
            >
              <option value="0">...all posts</option>
              {tags.map((t) => (
                <option key={t.id} value={t.id}>
                  {t.name}
                </option>
              ))}
            </Input>
            
            {
                error
                    // Handle the error and display a user-friendly message                   
                    ?<div>
                        <p>{error.message}</p>
                    </div>
                    :<div></div>       
            }



            </FormGroup>


            <div style={{ padding: "1rem" }}>
                <Button 
                onClick={(e) => {

                handleNavigate(e)
            }}>
                New Post
            </Button>
            </div>

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
                                <Link to={`/posts/${p.id}/comments`}>
                                    View Comments
                                </Link>
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